; Manually optimized padovan

padovan:
	movl	4(%esp), %eax
	cmpl	$3, %eax
	jg		.L5
	movl	$1, %eax
	ret

.L5:
	subl	$2, %eax
	subl	$4, %esp
	pushl	%eax
	call	padovan
	movl	%eax, 4(%esp)
	subl	$1, (%esp)
	call	padovan
	addl	4(%esp), %eax
	addl	$8, %esp
	ret